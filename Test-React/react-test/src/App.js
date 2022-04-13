import './App.css';
import React from 'react';
import { useState } from 'react';

function App (){


  const [users, setUsers] = useState({
   
  })

  const [submitted, setSubmitted] = useState(false);
  
  const handleUserNameInputChange = (event) => {
    setUsers({...users, username:event.target.value})
  }
  
  const handlePasswordInputChange = (event) => {
    setUsers({...users, password:event.target.value})
  }

  const handleSubmit = (event) => {
    event.preventDefault();
    setSubmitted(true);
    console.log(users);
  }
  
  return(
    <div className="form-container">
        <form className="register-form" onSubmit={handleSubmit}>
          {submitted ? <div className="success-message">Success!</div> : null}
          <input
            onChange={handleUserNameInputChange}
            value={users.value}
            className="form-field"
            placeholder="Username"
            name="username" />
          <input
            onChange={handlePasswordInputChange}
            value={users.value}
            className="form-field"
            placeholder="Password"
            name="password" />
          <button
            className="form-field"
            type="submit">Register</button>
            
        </form>
    </div>
   
  )        
  
  

}
export default App;




