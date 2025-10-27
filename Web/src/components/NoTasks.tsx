import { CheckCircle2, Sparkles } from "lucide-react";

const NoTasks = () => {
  return (
    <div className='flex flex-col items-center justify-center py-16 px-4'>
         <div className='relative mb-6'>
            <div className='w-24 h-24 bg-secondary-20 rounded-3xl flex items-center justify-center'>
                <CheckCircle2 className="w-12 h-12 text-primary" />
            </div>
            <div className='absolute -top-2 -right-2'>
                <Sparkles className="w-6 h-6 text-secondary" />
            </div>
         </div>
         <h3 className="text-2xl font-bold text-foreground mb-2">All clear! 🎉</h3>
         <p className="text-gray-500 text-center max-w-md">No tasks found. Add one above to get started on your productivity journey!</p>
    </div>
  )
}

export default NoTasks