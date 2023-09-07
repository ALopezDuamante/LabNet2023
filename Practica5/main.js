const mainView = document.getElementById("mainView");
const gameView = document.getElementById("gameView");

const gameLabel = document.getElementById("gameLabel");
const finalLabel = document.getElementById("endLabel");

const startButton = document.getElementById("startButton");
const submitButton = document.getElementById("submitButton");
const newGameButton = document.getElementById("newGameButton");

const numberTry = document.getElementById("numberTry");
const highscore = document.getElementById("highscore");
const showScore = document.getElementById("showScore");
const tryList = document.getElementById("tryList");
const numberToGuess = document.getElementById("numberToGuess");
const gameOver = document.getElementById("gameOver");

let random = Math.ceil((Math.random()*20));
let maxScore = 0;
let actualScore = 5;

showScore.textContent = actualScore;

startButton.addEventListener("click", function(){
    console.log(random);
    mainView.style.display = "none";
    gameView.style.display = "block";
    highscore.textContent = maxScore;
})

newGameButton.addEventListener("click", function(){
    endLabel.style.display = "none";
    gameLabel.style.display = "block";
    while (tryList.firstChild) {
        tryList.removeChild(tryList.firstChild);
    }
    random = Math.ceil((Math.random()*20));
    actualScore = 5;
    console.log(random);
})

submitButton.addEventListener("click", function(){
    const tryValue = numberTry.value;
    const li = document.createElement("li");
    if(tryValue == random){
        if (maxScore < actualScore){
            maxScore = actualScore;
            
        }
        gameLabel.style.display = "none";
        endLabel.style.display = "block";
        gameOver.textContent = "Ganaste";
        highscore.textContent = maxScore;
        numberToGuess.textContent = random;   
    }
    if(tryValue < random){;
        actualScore--;
        li.textContent = tryValue + " - Muy bajo";
        tryList.appendChild(li);
    }
    if(tryValue > random){
        actualScore--
        li.textContent = tryValue + " - Muy alto";
        tryList.appendChild(li);

    }
    if(actualScore == 0){
        gameLabel.style.display = "none";
        endLabel.style.display = "block";
        gameOver.textContent = "Perdiste";
        numberToGuess.textContent = random;
    }
    showScore.textContent = actualScore;
})
