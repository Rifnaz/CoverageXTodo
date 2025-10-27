import React from 'react'
import { type OsId, OperationalStatusEnum } from '../../types/Tasks';

interface OsButtonProps {
  isActive: boolean;
  osId: OsId;
  onSelect: (osId : OsId) => void;
};

const OsButton: React.FC<OsButtonProps> = ({ isActive, osId, onSelect }) => {
  let label = "All";

  if(osId == OperationalStatusEnum.Pending)
    label = "🕓 To Do";
  else if (osId == OperationalStatusEnum.Completed)
    label = "✅ Completed";

  return (
    <button
      onClick={() => onSelect(osId)}
      className={`inline-flex items-center justify-center gap-2 mt-5 whitespace-nowrap font-medium text-sm hover:bg-primary/90 h-11 rounded-xl hover:opacity-90 transition-opacity shadow-soft px-6 py-5 cursor-pointer 
        ${isActive 
          ? "bg-primary text-white" 
          : "bg-light text-gray-500 border border-border bg-primary-hover hover:text-white"}`
      }
    >
      {label}
    </button>
  )
}

export default OsButton