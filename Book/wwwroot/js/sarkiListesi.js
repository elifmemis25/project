var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/sarki",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "sarkiAd", "width": "20%" },
            { "data": "sarkici", "width": "20%" },
            { "data": "album", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                           <a href="/SarkiListesi/GuncelleEkle?id=${data}" class="btn btn-success text-white' style="cursor:pointer; width:80px;'>
                      Düzenle </a>
                        
                      <a class="btn btn-danger text-white" style='cursor:pointer; width:80px;' onclick=Delete('/api/sarki?id='+${data})> Sil </a>  
                   </div>`;

                }, "width": "40%"
            }

        ],

        "language": {
            "emptyTable": "Veri bulunamadı!"
        },

        "width": "100%"
    });
}
function Delete(url) {
    swal({
        title: "Silmek istediğinizden emin misiniz?",
        text: "İlgili veri silinirse tekrar geri döndürülemeyecektir!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((silinecekmi) => {
        if(silinecekmi) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                    toastr.error(data.message);
                }
            }
            })
}
    })
}