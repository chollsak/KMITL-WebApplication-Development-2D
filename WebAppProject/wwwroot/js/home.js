function expandCard(button) {
    var card = button.closest('.card');
    var additionalInfo = card.querySelector('.additional-info');

    // Toggle the 'expanded' class on the card
    card.classList.toggle('expanded');

    if (card.classList.contains('expanded')) {
        // If the card is now expanded, change the button text to 'Show Less'
        button.textContent = 'น้อยลง';
        button.classList.add('less');
    } else {
        // If the card is now collapsed, change the button text to 'Show More'
        button.textContent = 'ข้อมูลเพิ่มเติม';
        button.classList.remove('less');
    }

    // Toggle the visibility of additional information
    additionalInfo.classList.toggle('show');
}

// Get the modal
var modal = document.getElementById("myModal");

// Get the button that opens the modal
var btn = document.querySelector(".card-button-green");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal 

function showModal() {
    modal.style.display = "block";
    setTimeout(function() {
      modal.style.display = "none";
    }, 2000); // 2000 milliseconds = 2 seconds
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

var editModalButton = document.getElementById("editModal");
var span2 = document.getElementsByClassName("close")[1];

function editModal() {
    editModalButton.style.display = "block";
    
}

span2.onclick = function() {
  editModalButton.style.display = "none";
}

window.onclick = function(event) {
  if (event.target == editModalButton) {
    editModalButton.style.display = "none";
  }
}

var span3 = document.getElementsByClassName("close")[2];

var deleteModalButton = document.getElementById("deleteModal");
var span4 = document.getElementsByClassName("close")[3];
function deleteModal() {
  deleteModalButton.style.display = "block";
}

var deleteCompleteModalButton = document.getElementById("deleteCompleteModal");
var span5 = document.getElementsByClassName("close")[3];

function deleteCompleteModal() {
  deleteCompleteModalButton.style.display = "block";
    setTimeout(function() {
      deleteCompleteModalButton.style.display = "none";
    }, 2000);

    cancle();
}

function cancle(){
  editModalButton.style.display = "none";
  deleteModalButton.style.display = "none";

}



// Function to check if all form fields are empty
function checkFormEmpty() {
  var name = document.getElementById('name').value;
  var location = document.getElementById('location').value;
  var description = document.getElementById('description').value;
  var img = document.getElementById('img').value;
  var max = document.getElementById('max').value;
  var endDate = document.getElementById('end-date').value;

  if (name === '' && location === '' && description === '' && img === '' && max === '' && endDate === '') {
      alert('Please fill in at least one field.');
      return false;
  }
  
  return true;
}


// Define the end time
function getDayLeft(time) {
    // Update the year from 2567 to 2024
    time = time.replace("2567", "2024");


    var startTime = new Date(time); // yyyy-MM-dd HH:mm
    var endTime = new Date();

    var startMillis = startTime.getTime();
    var endMillis = endTime.getTime();

    var daysLeft = Math.floor((startMillis - endMillis) / (1000 * 60 * 60 * 24));

    console.log(daysLeft);

    document.getElementById("demo").innerHTML = "วันที่เหลือ: " + String(daysLeft) + " วัน";
}

