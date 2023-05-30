import { useState } from 'react';
import Task from '../Models/Task';
import GetTasksByParentId from '../Methods/GetTasksByParentId';
import "../App.css";

const TaskComponent = ({task, marginLeft} : {task: Task, marginLeft: number}) =>{
    const [tasks, setTasks] = useState<Task[]>();
    const [isLoading, setIsLoading] = useState<boolean>(false);

    return (
    <div style={{marginLeft: (marginLeft +"px")}} onClick={(
        (_) => 
        {
            if(!isLoading)
            {
                GetTasksByParentId(task.Id as string).then(result => setTasks(result));
                setIsLoading(true);
            }
        }
        )}>
        <div className="row">
            {task.TaskName + " - " +  task.CreatorName}
            {(isLoading && !tasks) && <div className="smallLoader"/>}
        </div>
        {tasks && tasks.map( task => <TaskComponent task={task} marginLeft={marginLeft+50}/>)}
    </div>
    );
}

export default TaskComponent;