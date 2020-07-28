// Chart
var chart;

$(document).ready(function () {
var options = {
    chart: {
        type: 'line',
        events: {
            load: requestData
        }
    },
    title: {
        text: 'KiwiSaver'
    },
    xAxis: {
        title: {
            text: 'Years to Retirement'
        }
    },
    yAxis: {
        title: {
            text: 'Asset Value'
        }
    },
    legend: {
        enabled: true
    },
    exporting: {
        enabled: false
    },
    series: [{
        name: 'KiwiSaver',
        data: []
    }]
};
chart = Highcharts.chart('ChartContainer', options)

//requestData();
});

// Data

function requestData() {
    $.ajax({
        url: '/api/DataMaster',
        type: "GET",
        dataType: "json",
        data: {},
        success: function (data) {
            data.forEach(function (arrayItem) {
                var vx = arrayItem.yearsToRetire;
                var vy = arrayItem.cumulativeKiwiSaver;
                chart.series[0].addPoint({ x: vx, y: vy })
            });
        },
        cache: false
    });
}

function getData() {
        fetch('/api/DataMaster').then(function (response) {
            return response.json()
        }).then(function (data) {

            data.forEach(function (arrayItem) {
                var vx = arrayItem.yearsToRetire;
                var vy = arrayItem.cumulativeKiwiSaver;
                chart.series[0].addPoint({ x: vx, y: vy });
            });

})
}