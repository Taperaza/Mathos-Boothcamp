import React from 'react';
import '../components/index.css';
import { Link } from 'react-router-dom'; 

function Nav(){
    return(
        <nav>
            <h3>Logo</h3>
            <ul className="nav-links">
                <Link to="/GetData">
                    <li>Shop</li>
                </Link>
                <Link to="/Form">
                    <li>Registration</li>
                </Link>
            </ul>
        </nav>
    );
};

export default Nav;