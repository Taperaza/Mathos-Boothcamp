import React from 'react';
import { Component } from 'react';
import '../components/index.css';

class Form extends Component{
    constructor(props) {
        super(props)
        let userInfo = {username:"",password:"",email:""}
        this.state = {
            users:[userInfo],
            user:{}
        };
    
        this.handleSubmit=this.handleSubmit.bind(this)
    }
    userHandler = (event) =>{
        this.setState({username: event.target.value});
    }

    passwordHandler = (event) =>{
        this.setState({password: event.target.value});
    }

    emailHandler = (event) =>{
        this.setState({email: event.target.value});
    }

    handleSubmit = (event) =>{
        alert('Registered Successfully!')
        console.log(this.state);
        this.setState({
            username:"",
            password:"",
            email:""
        })
     event.preventDefault();
        
    }

    render(){
        const {username,password,email} = this.state;
        return(
        <div>
            <form onSubmit = {this.handleSubmit}>
                <label>Username: </label>
                <input type ="text"
                       name ="username"
                       value={username}
                       onChange={this.userHandler}/>
                <br/>
                <label>Password: </label>
                <input type ="password"
                       name ="password"
                       value={password}
                       onChange={this.passwordHandler}/>
                <br/>
                <label>Email: </label>
                <input type ="email"
                       name ="email"
                       value={email}
                       onChange={this.emailHandler}/>
                <br/>
                <button type="submit">Register</button>
            </form>
            <table id ="infoTable">
                <tr>
                    <th>Username  </th>
                    <th>Password  </th>
                    <th>Email  </th>
                </tr>
                {this.state.users.map(item=>(
                    <tr>
                        <td>{item.username}</td>
                        <td>{item.password}</td>
                        <td>{item.email}</td>
                    </tr>
                ))}

            </table>
        </div>
            
        )
    }       
}
export default Form