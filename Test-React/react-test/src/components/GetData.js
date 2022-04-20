import React, {Component} from 'react';
import { Table, Button } from 'reactstrap';
import '../components/index.css';
import axios from 'axios' ;
import 'bootstrap/dist/css/bootstrap.min.css';

class GetData extends Component {
    state = {
        vehicles: []
    }
    componentWillMount() {
        axios.get('https://localhost:44313/api/Vehicle').then((response) =>{
            this.setState({
                vehicles: response.data
                
            })
            console.log(response.data);
        });
    }
    render(){
        let vehicles = this.state.vehicles.map((vehicle) =>{
            return(
              <tr key ={vehicle.ID}>
                    <td>{vehicle.ID}</td>
                    <td>{vehicle.CarBrand}</td>
                    <td>{vehicle.CarModel}</td>
                    <td>{vehicle.ProductionYear}</td>
                    <td>{vehicle.Usage}</td>
                    <td>
                      <Button color="success" size="sm">Edit</Button>
                      <Button color="danger" size="sm">Delete</Button>
                    </td>
               </tr>
            )

        });
        return(
         <div className = "Data container">
             <Table>
               <thead>
                   <tr>
                       <th>#</th>
                       <th>Car Brand</th>
                       <th>Car Model</th>
                       <th>Production Year</th>
                       <th>Usage</th>
                   </tr>
                </thead> 

                <tbody>
                    {vehicles}
                </tbody>   
             </Table>
         </div>
        )
    }
}
export default GetData;