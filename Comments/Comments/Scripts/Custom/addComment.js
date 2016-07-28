﻿$(document).ready(function () {

	var isAvatarUploaded = false;
	var commentsCount = +($("#commentsCount").text());

	$("#Gender").on("change", function () {
		if (!isAvatarUploaded) {
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
		var form = $("#addCommentForm");
		if (form.valid()) {
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

						commentsCount += 1;
						$("#commentsCount").text(commentsCount)
					},
					error: function (xhr, status, p3) {
						if (p3 == "Bad Request") {
							var errors = JSON.parse(xhr.responseText);
							addErrors(errors);
						}
						else {
							alert(xhr.responseText);
						}
					}
				});
			} else {
				alert("Браузер не поддерживает загрузку файлов HTML5!");
			}
		}
	});

	$("#upload").change(function () {
		readURL(this);
	});

	function readURL(input) {
		if (input.files && input.files[0]) {
			var reader = new FileReader();

			reader.onload = function (e) {
				$('#image').attr('src', e.target.result);
			}

			reader.readAsDataURL(input.files[0]);
			isAvatarUploaded = true;
		}
	}

	function clearFields() {
		isAvatarUploaded = false;
		$("#UserName").val("");
		$("#Date").val("");
		$("#Gender").val("0");
		$("#Text").val("");
		document.getElementById('upload').value = null;
	}

	function addErrors(errors) {
		for (var i = 0; i < errors.length; i++) {
			
		}
	}
});