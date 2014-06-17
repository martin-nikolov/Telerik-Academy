window.onload = function() {

    var gridView = createGridView();
    $('#wrapper').append(gridView);

    function createGridView() {
        var gridViewContainer = $('<div/>').addClass('grid-view');
        var gridViewControls = $('<div/>').addClass('grid-view-controls');

        var table = $('<table/>').addClass('grid-view-table');
        var thead = null;
        var tbody = $('<tbody/>');
        table.append(tbody);

        gridViewContainer.append(gridViewControls);
        gridViewContainer.append(table);

        var nestedGridViews = $('<div/>').addClass('nested-grid-views');

        var addRowButton = $('<button/>').addClass('grid-view-control').text('Add Row');
        addRowButton.on('click', function() {
            var tableRow = $('<tr/>');
            var tableCol = $('<td/>').text('Row');
            tableRow.append(tableCol);
            tbody.append(tableRow);
        });

        var addRemoveHeaderButton = $('<button/>').addClass('grid-view-control').text('Add/Remove Header');
        addRemoveHeaderButton.on('click', function() {
            if (!thead) {
                thead = $('<thead/>');
                var tableRow = $('<tr/>');
                var tableCol = $('<td/>').text('HEADER');
                tableRow.append(tableCol);
                thead.append(tableRow);
                table.append(thead);
            } else {
                thead.remove();
                thead = null;
            }
        });

        var addGridView = $('<button/>').addClass('grid-view-control').text('Add Grid-View');
        addGridView.on('click', function() {
            nestedGridViews.append(createGridView());
        });

        gridViewControls.append(addRowButton);
        gridViewControls.append(addRemoveHeaderButton);
        gridViewControls.append(addGridView);
        gridViewContainer.append(nestedGridViews);
        return gridViewContainer;
    }
};