var numberOfDrumButtons = document.querySelectorAll(".drum").length;

//detecting button press
for (let i = 0; i < numberOfDrumButtons; i++) {
    document.querySelectorAll(".drum")[i].addEventListener("click", function () {
    var buttonInnerHTML = this.innerHTML;
    makeSound(buttonInnerHTML);
    buttonAnimation(buttonInnerHTML);
    });
}

//detecting keyboard press
document.addEventListener("keydown", function(event) {
    makeSound(event.key);
    buttonAnimation(event.key);
});

// Function to play sound
function playSound(sound) {
    var audio = new Audio(sound);
    audio.play();
}

//function to make sound
function makeSound(key) {
    switch (key) {
        case "w":
            playSound("sounds/tom-1.mp3");
            break;

        case "a":
            playSound("sounds/tom-2.mp3");
            break;

        case "s":
            playSound("sounds/tom-3.mp3");
            break;

        case "d":
            playSound("sounds/tom-4.mp3");
            break;

        case "j":
            playSound("sounds/snare.mp3");
            break;

        case "k":
            playSound("sounds/kick-bass.mp3");
            break;

        case "l":
            playSound("sounds/crash.mp3");
            break;
    
        default:
            console.log(key+ " is not a valid key.");
            break;
            
    }
}

function buttonAnimation(currentKey){

    var activeButton = document.querySelector("." + currentKey);
    activeButton.classList.add("pressed");

    setTimeout(function(){
        activeButton.classList.remove("pressed");
    }, 100);
    
}