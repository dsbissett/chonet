window.onresize=ShowAdDiv;
 
	function FloatTopDivLeft()
	{
		startX = ((document.body.clientWidth -815)/2) - 10 - 95, startY = 110;
		var d = document;
		
		function ml(id)
		{
			var el=d.getElementById?d.getElementById(id):d.all?d.all[id]:d.layers[id];
			el.sP=function(x,y){this.style.left=x;this.style.top=y;};
			el.x = startX;
			el.y = startY;
			return el;
		}
		
		window.stayTopLeft=function()
		{
			if (document.documentElement && document.documentElement.scrollTop)
				var pY =  document.documentElement.scrollTop;
			else if (document.body)
				var pY =  document.body.scrollTop;
				
			if (document.body.scrollTop > 71)
			{
				startY = 3
			}
			else 
			{
				startY = 110
			};
			
			ftlObjLeft.y += (pY + startY - ftlObjLeft.y) / (66 - 60);
			ftlObjLeft.sP(ftlObjLeft.x, ftlObjLeft.y);
			setTimeout("stayTopLeft()", 20);
		}
		
		ftlObjLeft = ml("divAdLeft");
		stayTopLeft();
	}	

	function ShowAdDiv()
	{
		var objAdDivLeft = document.getElementById("divAdLeft");
		
		if (document.body.clientWidth < 778)
		{
		    objAdDivLeft.style.display = "none";
		    
		}
		else
		{
			objAdDivLeft.style.display = "block";
			FloatTopDivLeft();
						
		}
	}
	
	ShowAdDiv();