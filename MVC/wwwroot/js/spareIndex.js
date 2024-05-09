let selectedValue = document.getElementById("dropdown").value;

let selectedGroup = document.getElementById("group-dropdown").value;

let dropdown = document.getElementById("group-dropdown");
let selectedText = dropdown.options[dropdown.selectedIndex].text;

document.getElementById('dropdown').addEventListener('change', function () {
   selectedValue = this.value;
});

document.getElementById('group-dropdown').addEventListener('change', function () {
   selectedGroup = this.value;
   selectedText = this.options[dropdown.selectedIndex].text;
});

function submitForm() {
   const inputFieldValue = document.getElementById('inputField').value;
   // Construct the full URL including the base path to your controller action
   const baseUrl = window.location.origin; // Gets the current origin (protocol + hostname + port)
   const actionPath = '/Spares/Index'; // The path to your controller action
   const queryString = `?currentSearchBy=${selectedValue}&&currentFilterByValue=${selectedText}&&currentsearchValue=${inputFieldValue}`; // The query string

   const url = `${baseUrl}${actionPath}${queryString}`;


   // Redirect to the constructed URL to trigger a GET request and refresh the page
   window.location.href = url;
}

// Attach event listener to the input field to submit the form on Enter key press
document.getElementById('inputField').addEventListener('keydown', function (event) {
   if (event.key === "Enter") {
      event.preventDefault(); // Prevent the default action (which is to create a new line)
      submitForm(); // Call the submitForm function
   }
});