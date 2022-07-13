
$("#person-form").submit(function (event) {
    event.preventDefault();
    var formData = $(this).serialize();
    $.ajax({
        url: '/kisi-ekle',
        type: 'POST',
        dataType: 'json',
        data: formData,
        success: function (response) {
            if (response.isSuccess) {
                Swal.fire({
                    icon: 'success',
                    title: 'Kişi ekleme işlemi başarılı.Kişi listesine yönlendiriliyorsunuz.',
                    showConfirmButton: false,
                    timer: 3000
                })
                setTimeout(function () {
                    window.location.href = "kisi-listesi";
                }, 3000);
            }
            else {
                Swal.fire({
                    icon: 'error',
                    title: 'Hata',
                    text: 'Kişi ekleme sırasında bir hata oluştu.Lütfen bilgileri kontrol ederek tekrar deneyiniz.',
                    confirmButtonText: 'Tamam',
                })
            }          
        },
        error: function (err) {

        }
    });
});