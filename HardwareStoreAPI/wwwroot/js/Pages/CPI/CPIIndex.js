//////////////////////////////////////////
//ChartJS CPI Index Page
//////////////////////////////////////////


//CPI ChartsJS
let chartTitle = 'CPI Graph';

ShowLineChart(getCPIChartData);

//Line Chart

function ShowLineChart(results) {

	let myAmounts = [];
	let myDates = [];

	results.sort((a, b) => new Date(a.productCPIDateEntry) - new Date(b.productCPIDateEntry));

	for (let i = 0; i < results.length; i++) {
		myAmounts.push(parseFloat(results[i].cpiIndexValue));
		console.log(parseFloat(results[i].cpiIndexValue));
		myDates.push(results[i].productCPIDateEntry.slice(0, 10));
	}

	let popCanvasName = document.getElementById("lineChart");
	new Chart("lineChart", {
		type: 'line',
		data: {
			labels: myDates,
			datasets: [{
				label: 'CPI Index data',
				data: myAmounts,
				backgroundColor: "rgba(0,0,255,1.0)"
			}]
		},
		options: {
			responsive: true,
			scales: {
				yAxes: [{
					ticks: {
						beginAtZero: true,
						min: 0,
						max:100
					}
				}]
			},
			plugins: {
				title: {
					display: true,
					text: chartTitle,
					font: {
						size: 20
					}
				}
			}
		}
	});
}