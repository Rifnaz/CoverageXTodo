import React from 'react'
import { type OsId, type Tasks, OperationalStatus } from "../types/Tasks";
import { CheckCircle2, Trash2, RotateCcw } from "lucide-react";

interface TaskProps {
  task: Tasks;
  onDelete: (id : number) => void;
  onOsChange: (id : number, osId : OsId) => void;
};

const TaskCard : React.FC<TaskProps> = ({task, onDelete, onOsChange}) => {
  return (
    <div key={task.id} className='bg-white rounded-xl p-6 shadow-md border border-border group mb-3'>
        <div className="flex items-start justify-between gap-4">
            <div className="flex-1 min-w-0">
                <h3 className="text-lg font-semibold mb-2 group-hover:text-primary transition-colors text-foreground">{task.title}</h3>
                <p className="text-sm text-muted-foreground leading-relaxed">{task.description}</p>
            </div>
                
            <div className="flex gap-2 shrink-0">
              {OperationalStatus[task.osId] == "Pending" ? (
                <button onClick={() => onOsChange(task.id, task.osId)} className='inline-flex items-center justify-center gap-2 whitespace-nowrap text-sm font-medium border border-input h-9 rounded-xl px-3 bg-light hover:!bg-green-600 hover:text-white cursor-pointer transition-all'>
                  
                  <CheckCircle2 className="w-4 h-4" /> Complete
                </button>
              ) : (
                  <button onClick={() => onOsChange(task.id, task.osId)} className='inline-flex items-center justify-center gap-2 whitespace-nowrap text-sm font-medium border border-input h-9 rounded-xl px-3 bg-green-600 text-white hover:bg-green-800 cursor-pointer transition-all'>
                  
                  <RotateCcw className="w-4 h-4" /> Completed
                </button>
              )

              }
                
                <button onClick={() => onDelete(task.id)} className='inline-flex items-center justify-center gap-2 whitespace-nowrap text-sm font-medium border border-input h-9 rounded-xl px-3 bg-light hover:!bg-rose-600 hover:text-white cursor-pointer  transition-all'>
                <Trash2 className="w-4 h-4" />
                </button>
            </div>
        </div>
    </div>
  )
}

export default TaskCard