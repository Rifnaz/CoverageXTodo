import { useEffect, useState } from "react";
import { taskApi } from "../api/taskApi";
import type { Tasks, OperationalStatus, OsId } from "../types/Tasks";
import { Plus } from "lucide-react";
import TaskCard from "./TaskCard";
import { toast } from 'react-toastify';


const TaskForm = () => {

    const [tasks, setTasks] = useState<Tasks[]>([]);
    const [loading, setLoading] = useState(false);

    const [frmTask, setFrmTask] = useState<Tasks>({
        id: 0,
        title: "",
        description: "",
        osId: 1,
        addedDate: ""
    });

    const clearFields = () => {
        setFrmTask({
            id: 0,
            title: "",
            description: "",
            osId: 1,
            addedDate: ""
        })
    }

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setFrmTask((prev) => ({ ...prev, [name]: value }));
    };

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        if(!frmTask.title || !frmTask.description){
            toast.error("Fill both fields.");
            setLoading(false);
            return;
        }
            
        try {
            const res = await taskApi.create(frmTask);

            if(!res.succeed){
                toast.error(res.message);
                return;
            }

            clearFields();
            toast.success(res.message);
            fetchTasks();

        } catch(error) {
            console.error("Error adding tasks:", error);
        }
    }

    const handleDelete = async (id : number) => {
        try {
            const res = await taskApi.delete(id);

            if(!res.succeed){
                toast.error(res.message);
                return;
            }

            toast.success(res.message);
            fetchTasks();

        } catch(error) {
            console.error("Error deleting tasks:", error);
        }
    }

    const handleStatus = async (id : number, osId : OsId) => {
         try {
            const res = await taskApi.updateStatus(id, osId);

            if(!res.succeed){
                toast.error(res.message);
                return;
            }

            toast.success(res.message);
            fetchTasks();

        } catch(error) {
            console.error("Error updating task:", error);
        }
    }

    const fetchTasks = async () => {
        setLoading(true);

        try {
            const data = await taskApi.getAll();
            setTasks(data);

        } catch (error){
            console.error("Error fetching tasks:", error);
        } finally {
            setLoading(false);
        }
    }

    useEffect(() => {
        fetchTasks();
    }, []);

  return (
    <section id="Task" className='max-w-6xl mx-auto px-4 py-12'>
        <form className='w-full max-w-2xl mx-auto mb-8' onSubmit={handleSubmit}>
            <div className='bg-white rounded-2xl p-6 shadow-md border border-border'>
                <input 
                type="text" 
                className='flex h-10 w-full rounded-md border-inpu px-3 py-2 md:text-sm text-lg font-medium border-0 bg-input' placeholder='Task Title...'
                value={frmTask.title} 
                name="title" 
                onChange={handleChange}/>

                <textarea 
                className='flex w-full rounded-md border-input mt-5 px-3 py-2 md:text-sm text-lg font-medium border-0 bg-input min-h-[80px]' 
                placeholder='Add a description...'
                rows={5}
                value={frmTask.description} 
                name="description"
                onChange={handleChange}></textarea>

                <button className='inline-flex items-center justify-center gap-2 mt-5 whitespace-nowrap font-medium text-sm bg-primary hover:bg-primary/90 h-11 rounded-xl bg-gradient-to-r hover:opacity-90 transition-opacity shadow-soft px-8 py-6 text-white w-full cursor-pointer'>
                    <Plus className="w-5 h-5 mr-2 text-sm" type="submit"/>
                    Add Task
                </button>
            </div>
        </form>

        {loading ? (
            <p>Loading...</p>
        ) : (
            tasks.map((task) => <TaskCard key={task.id} task={task} onDelete={() => handleDelete(task.id)} onOsChange={() => handleStatus(task.id, task.osId)}/>)
        )}
        
    </section>
  )
}

export default TaskForm