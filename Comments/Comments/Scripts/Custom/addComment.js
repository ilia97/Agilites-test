$(document).ready(function () {

	$("#Gender").on("change", function () {
		if (!$("#File").val()) {
			if ($("#Gender").val() == "1") {
				$("#image").attr("src", "/Pictures/FemaleDefault.png");
			}
			else {
				$("#image").attr("src", "/Pictures/MaleDefault.png");
			}
		}
	});

	$("#addCommentBtn").on("click", function (e) {
		e.preventDefault();
		var files = document.getElementById('upload').files;
		if (window.FormData !== undefined) {
			var data = new FormData();
			data.append("UserName", $("#UserName").val());
			data.append("Date", $("#Date").val());
			data.append("Gender", $("#Gender").val());
			data.append("Text", $("#Text").val());
			if (files.length > 0) {
				for (var x = 0; x < files.length; x++) {
					data.append("file" + x, files[x]);
				}
			}

			$.ajax({
				type: "POST",
				url: '/Home/AddComment',
				contentType: false,
				processData: false,
				data: data,
				success: function (result) {
					$("#commentsList").html(result);
					clearFields();
				},
				error: function (xhr, status, p3) {
					alert(xhr.responseText);
				}
			});
		} else {
			alert("Браузер не поддерживает загрузку файлов HTML5!");
		}
	});

	$("#iconInputBtn").on("click", function () {
		$("#upload").click();
	});

	var clearFields = function () {
		$("#UserName").val("");
		$("#Date").val("");
		$("#Gender").val("1");
		$("#Text").val("");
		document.getElementById('upload').value = null;
	}
});