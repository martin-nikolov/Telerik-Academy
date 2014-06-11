var DAYS_OF_WEEK = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
var MONTH = 'June';
var YEAR = '2014';
var MAX_DAYS = 30;

function createCalendar(selector, events) {
    var table = createTable(events);
    setStylesAndEvents(table);

    var container = document.querySelector(selector);
    container.appendChild(table);
}

function createTable(events) {
    var table = document.createElement('table');
    var tr = document.createElement('tr');

    for (var currentDay = 1; currentDay <= MAX_DAYS; currentDay++) {
        var titleDiv = document.createElement('div');
        titleDiv.className = 'day-title';
        titleDiv.innerHTML = titleToString(currentDay);

        var eventsContainer = document.createElement('div');
        eventsContainer.className = 'day-events';
        for (var j = 0; j < events.length; j++) {
            if ((events[j].date | 0) === currentDay) {
                eventsContainer.innerHTML = eventToString(events[j]);
                break;
            }
        }

        var td = document.createElement('td');
        td.className = 'day-col';
        td.appendChild(titleDiv);
        td.appendChild(eventsContainer);

        tr.appendChild(td);

        if (currentDay % 7 === 0) {
            table.appendChild(tr);
            tr = document.createElement('tr');
        }
    }

    table.appendChild(tr);
    return table;
}

function setStylesAndEvents(table) {
    table.style.borderCollapse = 'collapse';

    var allTds = table.getElementsByClassName('day-col');
    for (var i = 0; i < allTds.length; i++) {
        allTds[i].style.width = '125px';
        allTds[i].style.height = '105px';
        allTds[i].style.padding = '0';
        allTds[i].style.border = '2px solid black';
    }

    var allTitles = table.getElementsByClassName('day-title');
    for (var i = 0; i < allTitles.length; i++) {
        allTitles[i].style.marginTop = '-52px';
        allTitles[i].style.textAlign = 'center';
        allTitles[i].style.background = '#CCCCCC';
        allTitles[i].style.borderBottom = '1px solid black';
        addEventListeners(allTitles[i]);
    }
}

function addEventListeners(element) {
    element.addEventListener('click', onClick, false);
    element.addEventListener('mouseover', onMouseOver, false);
    element.addEventListener('mouseout', onMouseOut, false);
}

function onClick(e) {
    e.target.style.background = '#FFFFFF';

    if (e.target.className.indexOf('day-title') != -1) {
        var lastCurrent = document.getElementById('current');
        if (lastCurrent) {
            lastCurrent.removeAttribute('id');
            addEventListeners(lastCurrent);
            onMouseOut(lastCurrent);
        }

        e.target.setAttribute('id', 'current');
        e.target.removeEventListener('click', onClick, false);
        e.target.removeEventListener('mouseover', onMouseOver, false);
        e.target.removeEventListener('mouseout', onMouseOut, false);
    }
}

function onMouseOver(e) {
    (e.target || e).style.background = '#999999';
}

function onMouseOut(e) {
    (e.target || e).style.background = '#CCCCCC';
}

function titleToString(currentDay) {
    return DAYS_OF_WEEK[(currentDay - 1) % 7] + ' ' + currentDay + ' ' + MONTH + ' ' + YEAR;
}

function eventToString(eventData) {
    return eventData.hour + ' ' + eventData.title;
}