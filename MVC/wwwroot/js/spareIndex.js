let selectedValue = document.getElementById("dropdown").value;
document.getElementById('dropdown').addEventListener('change', function () {
   selectedValue = this.value;
});
function submitForm() {
   const inputFieldValue = document.getElementById('inputField').value;
   // Construct the full URL including the base path to your controller action
   const baseUrl = window.location.origin; // Gets the current origin (protocol + hostname + port)
   const actionPath = '/Spares/Index'; // The path to your controller action
   const queryString = `?${selectedValue}=${inputFieldValue}&&currentSearchBy=${selectedValue}`; // The query string

   const url = `${baseUrl}${actionPath}${queryString}`;

   console.log(selectedValue);
   console.log(url);

   // Redirect to the constructed URL to trigger a GET request and refresh the page
   window.location.href = url;
}