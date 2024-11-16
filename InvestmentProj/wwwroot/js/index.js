@{
    var tempDataValue = TempData["Message"]?.ToString() ?? "No message";
}
<script>
    const tempDataValue = '@tempDataValue';
    console.log(tempDataValue); // Now you can use this variable in your JS code
</script>

document.querySelectorAll('.dropdown-toggle').forEach(item => {
    item.addEventListener('click', event => {

        if (event.target.classList.contains('dropdown-toggle')) {
            event.target.classList.toggle('toggle-change');
        }
        else if (event.target.parentElement.classList.contains('dropdown-toggle')) {
            event.target.parentElement.classList.toggle('toggle-change');
        }
    })
});
