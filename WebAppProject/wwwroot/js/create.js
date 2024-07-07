// Get the modal
var modal = document.getElementById("myModal");

// Get the button that opens the modal
var btn = document.querySelector(".card-button-green");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal 
// When the user clicks the button, open the modal 
function showModal() {
    modal.style.display = "block";
    setTimeout(function() {
      modal.style.display = "none";
      window.location.href = "../Views/Party/Index.cshtml"
    }, 3000); // 3000 milliseconds = 3 seconds
}


// When the user clicks on <span> (x), close the modal
span.onclick = function() {
  modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
}

// Function to check if all form fields are empty
function checkFormEmpty() {
  var name = document.getElementsByName('Name').value;
  var location = document.getElementsByName('location').value;
  var description = document.getElementsByName('description').value;
  var img = document.getElementsByName('img').value;
  var max = document.getElementsByName('Max').value;
  var endDate = document.getElementsByName('end-date').value;

  if (name === '' || location === '' || description === '' || img === '' || max === '' || endDate === '') {
      alert('Please fill in at least one field.');
      return false;
    }
  showModal(this);
    return true;
}
