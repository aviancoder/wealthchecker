// Chart
var chart;

$(document).ready(function () {
    var options = {
        lang: {
            decimalPoint: '.',
            thousandsSep: '\u002C'
        },
        chart: {
            events: {
                load: requestData
            },
            style: {
                fontFamily: 'Poppins'
            }
        },
        title: {
            text: 'Wealth Tracker',
            style: {
                color: '#17a2b8',
                fontSize: '1.5rem',
            }
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.y:,.2f}</b><br/>'
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
        plotOptions: {
            series: {
                marker: {
                    enabled: false
                },
                stacking: 'normal'
            }
        },
        series: [
            { stack: 1, type: 'area', name: 'Cash', data: [] },
            { stack: 1, type: 'area', name: 'Share / Business', data: [] },
            { stack: 1, type: 'area', name: 'Kiwi Saver', data: [] },
            { stack: 1, type: 'area', name: 'Home', data: [] },
            { stack: 1, type: 'area', name: 'Investment Prop 1', data: [] },
            { stack: 1, type: 'area', name: 'Investment Prop 2', data: [] },
            { stack: 1, type: 'area', name: 'Investment Prop 3', data: [] },
            { stack: 1, type: 'area', name: 'Debt', data: [] },
            { stack: 2, type: 'spline', name: 'Financial Goal', data: [] },
            { stack: 3, type: 'spline', name: 'Current Assets', data: [] },
        ]
    };
    chart = Highcharts.chart('ChartContainer', options);

});

// Data

function requestData() {
    getCash();
    getShareBusiness();
    getKiwiSaver();
    //getHome();
    getCurrentAssets();
    //getInvestmentProperty1();
    //getInvestmentProperty2();
    //getInvestmentProperty3();
    //getDebt();
    getFinancialGoal();
}

function getCash() {
    $.ajax({
        url: '/api/CashSavings',
        type: "GET",
        dataType: "json",
        data: {},
        success: function (data) {
            var dataItems = new Array();
            data.forEach(function (arrayItem) {
                dataItems.push(arrayItem.cumulativeCashSavings);
            });
            chart.series[0].setData(dataItems, false);
            chart.redraw();
        },
        cache: false
    });
}
function getShareBusiness() {
    $.ajax({
        url: '/api/ShareBusiness',
        type: "GET",
        dataType: "json",
        data: {},
        success: function (data) {
            var dataItems = new Array();
            data.forEach(function (arrayItem) {
                dataItems.push(arrayItem.cumulativeShareBusiness);
            });
            chart.series[1].setData(dataItems, false);
            chart.redraw();
        },
        cache: false
    });
}

function getKiwiSaver() {
    $.ajax({
        url: '/api/KiwiSaver',
        type: "GET",
        dataType: "json",
        data: {},
        success: function (data) {
            var dataItems = new Array();
            data.forEach(function (arrayItem) {
                dataItems.push(arrayItem.cumulativeKiwiSaver);
            });
            chart.series[2].setData(dataItems, false);
            chart.redraw();
        },
        cache: false
    });
}

function getHome() {
    $.ajax({
        url: '/api/DataMaster',
        type: "GET",
        dataType: "json",
        data: {},
        success: function (data) {
            var dataItems = new Array();
            data.forEach(function (arrayItem) {
                dataItems.push(arrayItem.cumulativeKiwiSaver);
            });
            chart.series[3].setData(dataItems, false);
            chart.redraw();
        },
        cache: false
    });
}

function getInvestmentProperty1() {
    $.ajax({
        url: '/api/DataMaster',
        type: "GET",
        dataType: "json",
        data: {},
        success: function (data) {
            var dataItems = new Array();
            data.forEach(function (arrayItem) {
                dataItems.push(arrayItem.cumulativeKiwiSaver);
            });
            chart.series[4].setData(dataItems, false);
            chart.redraw();
        },
        cache: false
    });
}

function getInvestmentProperty2() {
    $.ajax({
        url: '/api/DataMaster',
        type: "GET",
        dataType: "json",
        data: {},
        success: function (data) {
            var dataItems = new Array();
            data.forEach(function (arrayItem) {
                dataItems.push(arrayItem.cumulativeKiwiSaver);
            });
            chart.series[5].setData(dataItems, false);
            chart.redraw();
        },
        cache: false
    });
}

function getInvestmentProperty3() {
    $.ajax({
        url: '/api/DataMaster',
        type: "GET",
        dataType: "json",
        data: {},
        success: function (data) {
            var dataItems = new Array();
            data.forEach(function (arrayItem) {
                dataItems.push(arrayItem.cumulativeKiwiSaver);
            });
            chart.series[6].setData(dataItems, false);
            chart.redraw();
        },
        cache: false
    });
}

function getDebt() {
    $.ajax({
        url: '/api/DataMaster',
        type: "GET",
        dataType: "json",
        data: {},
        success: function (data) {
            var dataItems = new Array();
            data.forEach(function (arrayItem) {
                dataItems.push(arrayItem.cumulativeKiwiSaver);
            });
            chart.series[7].setData(dataItems, false);
            chart.redraw();
        },
        cache: false
    });
}

function getCurrentAssets() {
    $.ajax({
        url: '/api/CurrentAssets',
        type: "GET",
        dataType: "json",
        data: {},
        success: function (data) {
            var dataItems = new Array();
            data.forEach(function (arrayItem) {
                dataItems.push(arrayItem.cumulativeCurrentAssets);
            });
            chart.series[9].setData(dataItems, false);
            chart.redraw();
            chart.series[9].points[chart.series[9].points.length - 1].update({
                dataLabels: {
                    enabled: true, format: '${point.y:,.2f}', color: '#000000'
                }
            });
        },
        cache: false
    });
}

function getFinancialGoal() {
    $.ajax({
        url: '/api/FinancialGoal',
        type: "GET",
        dataType: "json",
        data: {},
        success: function (data) {
            var dataItems = new Array();
            data.forEach(function (arrayItem) {
                dataItems.push(arrayItem.cumulativeFinancialGoal);
            });
            chart.series[8].setData(dataItems, false);
            chart.redraw();
            chart.series[8].points[chart.series[8].points.length - 1].update({
                dataLabels: {
                    enabled: true, format: '${point.y:,.2f}', color: '#000000'
                }
            });
        },
        cache: false
    });
}

//function getData() {
//        fetch('/api/DataMaster').then(function (response) {
//            return response.json()
//        }).then(function (data) {

//            data.forEach(function (arrayItem) {
//                var vx = arrayItem.yearsToRetire;
//                var vy = arrayItem.cumulativeKiwiSaver;
//                chart.series[0].addPoint({ x: vx, y: vy });
//                chart.series[1].addPoint({ x: vx, y: vy });
//                chart.series[2].addPoint({ x: vx, y: vy });
//                chart.series[3].addPoint({ x: vx, y: vy });
//            });

//})
//}