//[widget charts Javascript]

//Project:	UniquePro Admin - Responsive Admin Template
//Primary use:   Used only for the  widget charts



$( document ).ready(function() {
    "use strict";
   

    var labels2 = [];
    if ($('#chart_8').length > 0) {
        $.ajax({
          
            type: "GET",
            url: "/ProjectStat/GetProjects",
            success: function (data) {
                $.each(data, function (i,v) {
                    labels2.push({
                        name,


                    });
                })
            }
                   
               
         
           
        })
        for (var s of labels2) {
            console.log(s);
        }
       

        var ctx2 = document.getElementById("chart_8").getContext("2d");
        var data2 = {
            labels:['ss'],
            
           

			datasets: [
				{
				    label: "first",
					backgroundColor: "rgba(0, 194, 146, 1)",
					borderColor: "rgba(0, 194, 146, 1)",
					data: [15, 20, 70, 51, 36, 85, 50]
				},
				{
					label: "My Second dataset",
					backgroundColor: "rgba(251, 150, 120, 1)",
					borderColor: "rgba(251, 150, 120, 1)",
					data: [28, 48, 40, 19, 86, 27, 90]
				},
				{
					label: "My Third dataset",
					backgroundColor: "rgba(171, 140, 228, 1)",
					borderColor: "rgba(171, 140, 228, 1)",
					data: [8, 28, 50, 29, 76, 77, 40]
				}
			]
		};
		
		var hBar = new Chart(ctx2, {
			type:"bar",
			data:data2,
			
			options: {
				tooltips: {
					mode:"label"
				},
				scales: {
					yAxes: [{
						stacked: true,
						gridLines: {
							color: "rgba(135,135,135,0)",
						},
						ticks: {
							fontFamily: "Poppins",
							fontColor:"#878787"
						}
					}],
					xAxes: [{
						stacked: true,
						gridLines: {
							color: "rgba(135,135,135,0)",
						},
						ticks: {
							fontFamily: "Poppins",
							fontColor:"#878787"
						}
					}],
					
				},
				elements:{
					point: {
						hitRadius:40
					}
				},
				animation: {
					duration:	3000
				},
				responsive: true,
				maintainAspectRatio:false,
				legend: {
					display: false,
				},
				
				tooltip: {
					backgroundColor:'rgba(33,33,33,1)',
					cornerRadius:0,
					footerFontFamily:"'Poppins'"
				}
				
			}
		});
	}
	
}); // End of use strict
