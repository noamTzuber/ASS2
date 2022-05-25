$(function () {
	$('form').submit(async e => {
		e.preventDefault();
		const q = $('#search').val();
		const response = await fetch('/Rates/Index2?query=' + q);
		const data = await response.json();
		const template = $('#template').html();
		let result = '';
		for (var item in data) {
			let row = template;
			for (var key in data[item]) {
				if (key == 'lastDate' && data[item][key] != null) {
					const d = new Date(data[item][key]);
					const newdate = addZero(d.getHours()) + ':' + addZero(d.getMinutes()) + '            ' + d.getDate() + '/' + (d.getMonth() + 1) + '/' + d.getFullYear();
					row = row.replaceAll('{' + key + '}', newdate);
				}
				else {
					row = row.replaceAll('{' + key + '}', data[item][key]);
					row = row.replaceAll('%7B' + key + '%7D', data[item][key]);
				}
			}
			
			result += row;
		}
		$('tbody').html(result);
	})
});