import './components/index.css';
import React from 'react';
import Nav from './components/Nav';
import Form from './components/Form';
import GetData from './components/GetData';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

function App (){
  return (
    <Router>
      <div className="App">
        <Nav />
        <Routes>
          <Route path ="/" element={<Home/>} />
          <Route path ="/getdata" element={<GetData/>} />
          <Route path ="/form" element={<Form/>} />
        </Routes>
      </div>
    </Router>
  );
};

const Home = () =>(
  <div>
    <h1>Home Page</h1>
  </div>
)

export default App;




