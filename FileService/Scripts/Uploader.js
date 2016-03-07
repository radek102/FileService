var Uploader = {
    uploadUrl: "Photos/Upload",
    uploadMethod: "POST",
    init: function(messageDivId, fileInputId, idInputId){
        this.messageDiv = document.getElementById(messageDivId);
        this.fileInput = document.getElementById(fileInputId);
        this.idInput = document.getElementById(idInputId);
    },
    uploadFile: function () {
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function (e) {
            if (this.readyState === 4) {
                Uploader.messageDiv.innerHTML = this.response;
            }
        };
        var file = Uploader.fileInput.files[0];
        var id = Uploader.idInput.value;
        xhr.open(Uploader.uploadMethod, Uploader.uploadUrl + "/" + id + "/" + file.name);
        xhr.setRequestHeader("filename", file.name);
        xhr.send(file); 
    }
}