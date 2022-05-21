! function (d) {
    "use strict";

    function r() { }
    r.prototype.respChart = function (r, o, e, a) {
        Chart.defaults.global.defaultFontColor = "#adb5bd", Chart.defaults.scale.gridLines.color = "rgba(108, 120, 151, 0.1)";
        var t = r.get(0).getContext("2d"),
            n = d(r).parent();

        function i() {
            r.attr("width", d(n).width());
            switch (o) {
                case "Pie":
                    new Chart(t, { type: "pie", data: e, options: a });
                    break;
                case "PolarArea":
                    new Chart(t, { data: e, type: "polarArea", options: a })
            }
        }
        d(window).resize(i), i()
    }, r.prototype.init = function () {
        this.respChart(d("#pie"), "Pie", { labels: ["Phiếu đã duyệt", "Phiếu chưa duyệt"], datasets: [{ data: [$("#dat").data("value"), $("#chuadat").data("value")], backgroundColor: ["#02a499", "#ebeff2"], hoverBackgroundColor: ["#02a499", "#ebeff2"], hoverBorderColor: "#fff" }] });
        this.respChart(d("#polarArea"), "PolarArea", { datasets: [{ data: [$("#xs").data("value"), $("#tot").data("value"), $("#kha").data("value"), $("#tbk").data("value"), $("#tb").data("value"), $("#yeu").data("value"), $("#kem").data("value")], backgroundColor: ["#38a4f8", "#02a499", "#ec4561", "#3c4ccf", "#f8b425", "#626ed4","#afb42b"], label: "My dataset", hoverBorderColor: "#fff" }], labels: ["Xuất sắc", "Tốt", "Khá", "Trung bình khá", "Trung bình", "Yếu", "Kém"] })
    }, d.ChartJs = new r, d.ChartJs.Constructor = r
}(window.jQuery),
    function () {
        "use strict";
        window.jQuery.ChartJs.init()
    }();