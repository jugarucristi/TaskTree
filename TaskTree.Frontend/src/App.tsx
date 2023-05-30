import React, { useEffect, useState } from 'react';
import './App.css';
import GetTasks from './Methods/GetTasks';
import Task from './Models/Task';
import TaskComponent from './Components/TaskComponent';

function App() {
  
  const [tasks, setTasks] = useState<Task[]>();

  useEffect(() => {
    GetTasks()
    .then(result => setTasks(result));
  },[]);

  return (
    <div className="App">
      <div>
        {tasks ? tasks.map( task => <TaskComponent task={task} marginLeft={0}/>) : <div className="loader"/>}
      </div>
    </div>
  );
}

export default App;
