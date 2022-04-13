setInterval(showTime, 1000);
function showTime() {
    let time = new Date();
    let hour = time.getHours();
    let min = time.getMinutes();
    let sec = time.getSeconds();
    am_pm = "AM";
  
    if (hour > 12) {
        hour -= 12;
        am_pm = "PM";
    }
    if (hour == 0) {
        hr = 12;
        am_pm = "AM";
    }
  
    hour = hour < 10 ? "0" + hour : hour;
    min = min < 10 ? "0" + min : min;
    sec = sec < 10 ? "0" + sec : sec;
  
    let currentTime = hour + ":" 
            + min + ":" + sec + am_pm;
  
    document.getElementById("clock")
            .innerHTML = currentTime;
}
showTime();

var users = [{}]
document.getElementById('registerButton').onclick = function() {
  var newUsername = document.getElementById('registerName').value
  var newPassword = document.getElementById('registerPassword').value
  users.push({ username: newUsername, password: newPassword })
}
document.getElementById('loginButton').onclick = function() {
  var username = document.getElementById('loginName').value
  var password = document.getElementById('loginPassword').value
  for (var i = 0; i < users.length; i++) {
    if (username == users[i].username) {
      if (password == users[i].password) {
        document.getElementById('loginResult').innerHTML = 'Success!'
        return
      } else {
        alert('wrong password')
      }
    }
  }

  alert('wrong username')
}