var x = "-286.901|-3916.077!-226.0467|-3891.989!-193.7439|-3879.142!-155.8435|-3912.808!-254.8753|-3907.751!";
var y = x.split("!");
var z = [];

for (var i = 0; i < y.length; i++)
{
	var obj = y[i].split("|");
	if (obj.length > 1)
		z.push({"x": parseFloat(obj[0]), "y": parseFloat(obj[1]), "w": 0.0, "h":0.0});
}
console.log(JSON.stringify(z));