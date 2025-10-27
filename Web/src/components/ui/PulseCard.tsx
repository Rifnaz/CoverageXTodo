import React from 'react'

const PulseCard = () => {
  return (
    <div className='bg-white rounded-xl p-6 shadow-md border border-border group mb-3'>
        <div className="flex animate-pulse space-x-4">
            <div className="flex-1 space-y-6 py-1">
                <div className="h-4 w-3/4 rounded-xl bg-gray-200"></div>
                <div className="h-3 rounded-xl bg-gray-200 mb-3"></div>
                <div className="h-3 w-7/8 rounded-xl bg-gray-200"></div>
            </div>
            <div className="w-1/5 space-y-6 py-1 flex gap-2 justify-end">
                <div className="h-8 w-24 rounded-xl bg-gray-200 mb-3"></div>
                <div className="h-8 w-8 rounded-xl bg-gray-200"></div>
            </div>
        </div>
    </div>
  )
}

export default PulseCard