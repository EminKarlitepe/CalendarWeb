$(function () {

    /* initialize the external events
     -----------------------------------------------------------------*/
    function ini_events(ele) {
        ele.each(function () {
            var eventObject = {
                title: $.trim($(this).text()),
                id: $(this).data('id')
            }
            $(this).data('eventObject', eventObject)
            $(this).draggable({
                zIndex: 1070,
                revert: true,
                revertDuration: 0
            })
        })
    }
    ini_events($('#external-events .external-event'));

    /* initialize the calendar
     -----------------------------------------------------------------*/
    var Draggable = FullCalendar.Draggable;
    new Draggable(document.getElementById('external-events'), {
        itemSelector: '.external-event',
        eventData: function (eventEl) {
            return {
                title: eventEl.innerText,
                id: $(eventEl).data('id'),
                backgroundColor: window.getComputedStyle(eventEl, null).getPropertyValue('background-color'),
                borderColor: window.getComputedStyle(eventEl, null).getPropertyValue('background-color'),
                textColor: window.getComputedStyle(eventEl, null).getPropertyValue('color'),
            };
        }
    });

    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        themeSystem: 'bootstrap',
        editable: true,
        droppable: true,
        events: {
            url: calendarUrls.getEvents,
            method: 'GET'
        },
        drop: function (info) {
            var eventId = $(info.draggedEl).data('id');
            var start = info.dateStr;
            var end = start;
            $.ajax({
                url: calendarUrls.updateDate,
                type: 'POST',
                data: { id: eventId, start: start, end: end },
                success: function (res) {
                    if (res.success) {
                        if ($('#drop-remove').is(':checked')) {
                            info.draggedEl.parentNode.removeChild(info.draggedEl);
                        }
                        // Olay takvime eklendikten sonra listeden silinse de silinmese de,
                        // takvimdeki olayları yeniden çekerek güncel veriyi gösterir.
                        calendar.refetchEvents();
                    }
                }
            });
        },
        eventDrop: function (info) {
            var eventId = info.event.id;
            var start = info.event.startStr;
            var end = info.event.endStr || start;
            $.ajax({
                url: calendarUrls.updateDate,
                type: 'POST',
                data: { id: eventId, start: start, end: end },
                success: function (res) {
                    if (res.success) {
                        calendar.refetchEvents();
                    }
                }
            });
        },
        eventResize: function (info) {
            var eventId = info.event.id;
            var start = info.event.startStr;
            var end = info.event.endStr || start;
            $.ajax({
                url: calendarUrls.updateDate,
                type: 'POST',
                data: { id: eventId, start: start, end: end },
                success: function (res) {
                    if (res.success) {
                        calendar.refetchEvents();
                    }
                }
            });
        },
        eventClick: function (info) {
            if (confirm("'" + info.event.title + "' başlıklı etkinliği silmek istediğinizden emin misiniz?")) {
                $.ajax({
                    url: calendarUrls.deleteEvent,
                    type: 'POST',
                    data: { id: info.event.id },
                    success: function (res) {
                        if (res.success) {
                            info.event.remove();
                            alert("Etkinlik başarıyla silindi!");
                            // Takvimden silinen olay, listedeki olaylardan biri olabilir.
                            // Bu durumda, listedeki olayı da kontrol etmeli ve kaldırmalıyız.
                            $('#external-events .external-event[data-id="' + info.event.id + '"]').remove();
                        } else {
                            alert("Etkinlik silinirken bir hata oluştu!");
                        }
                    },
                    error: function () {
                        alert("Etkinlik silinirken bir hata oluştu!");
                    }
                });
            }
        }
    });
    calendar.render();

    $('#event-form').submit(function (e) {
        e.preventDefault();
        var title = $('#event-title').val();
        var categoryId = parseInt($('#event-category').val());
        if (!categoryId) {
            alert('Lütfen bir kategori seçiniz!');
            return;
        }
        var color = $('#event-category option:selected').data('color') || '#3c8dbc';
        $.ajax({
            url: calendarUrls.addEvent,
            type: 'POST',
            data: { title: title, categoryId: categoryId },
            success: function (res) {
                if (res.success) {
                    $('#event-title').val("");
                    $('#event-category').val("");
                    var newEvent = '<div class="external-event" style="background-color:' + res.color + '; color:#fff; border-color:' + res.color + '" data-id="' + res.id + '">' + res.title + '</div>';
                    $('#external-events').prepend(newEvent);
                    // Yeni eklenen olayı draggable hale getirir
                    ini_events($('#external-events .external-event').first());
                } else {
                    alert(res.error || 'Etkinlik eklenirken bir hata oluştu!');
                }
            },
            error: function () {
                alert('Etkinlik eklenirken bir hata oluştu!');
            }
        });
    });
});