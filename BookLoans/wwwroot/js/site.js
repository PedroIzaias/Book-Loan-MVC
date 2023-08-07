$(document).ready(function () {
    $('#Loans').DataTable();

    setTimeout(() => { 
        $(".alert").fadeOut("slow", () => { 
            $(this).alert('close');
        })
    }, 3000)
});