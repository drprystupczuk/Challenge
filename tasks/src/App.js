import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import { useEffect, useState } from 'react';

function App() {

  const baseUrl = 'https://localhost:44369/api/Tasks';

  const [data, setData] = useState([]);
  const [showInsertModal, setShowInsertModal]=useState(false);
  const [task, setTask] = useState({
    name: '',
    description: ''
  });

  useEffect(() => {
    getRequest();
  }, [])

  const toggleInsertModal =() => {
    setShowInsertModal(!showInsertModal);
  }

  const handleChange = e => {
    const {name, value} = e.target;
    setTask({
      ...task,
      [name]: value
    });
  }

  const getRequest = async () => {
    await axios.get(baseUrl)
      .then(response => {
        console.log(response.data);
        setData(response.data);
      }).catch(error => {
        alert('Something went wrong! Please try again after a few seconds');
      })
  };

  const postRequest = async () => {
    await axios.post(baseUrl, task)
      .then(response => {
        console.log(response.data);
        setData(data.concat(response.data));
        toggleInsertModal();
      }).catch(error => {
        alert(error.response.data);
      })
  };
  
  return (
    <div className="App">
            <br></br>
      <button 
        onClick={()=>toggleInsertModal()}
        className='btn btn-success'
      >
        Insert New Task
      </button>
      <br></br>
      <br></br>
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th> Id </th>
            <th> Name </th>
            <th> Description </th>
          </tr>
        </thead>

        <tbody>
          {data.map(task => (
            <tr key={task.id}>
              <td>{task.id}</td>
              <td>{task.name}</td>
              <td>{task.description}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <Modal isOpen={showInsertModal}>
        <ModalHeader>
          Insert Task
        </ModalHeader>
        <ModalBody>
          <div className='form-group'>
            <label>Name:</label>
            <br></br>
            <input type="text" className="form-control" name="name" onChange={handleChange}/>
            <br></br>
            <label>Description:</label>
            <br></br>
            <input type="text" className="form-control" name="description" onChange={handleChange}/>
            <br></br>
          </div>
        </ModalBody>
        <ModalFooter>
          <button className='btn btn-primary' onClick={() => postRequest()}>Insert</button>{"   "}
          <button className='btn btn-danger' onClick={() => toggleInsertModal()}>Cancel</button>
        </ModalFooter>
      </Modal>

    </div>
  );
}

export default App;
