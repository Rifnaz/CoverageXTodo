import React from 'react'
import { ArrowDown } from "lucide-react";

const Hero = () => {
  return (
    <section className='relative py-20 px-4 text-center overflow-hidden'>
        <div className='max-w-3xl mx-auto space-y-6'>
                <h1 className="text-5xl md:text-7xl font-bold bg-gradient-to-r from-primary via-secondary to-primary bg-clip-text text-transparent">
                    Stay Focused,<br/>
                    Get Things Done
                </h1>
                <p className="text-lg md:text-xl text-gray-500 max-w-2xl mx-auto">
                    Your minimal productivity companion. Create, organize, and complete tasks with ease.
                </p>
                <a href='#Task' className='inline-flex items-center justify-center gap-2 whitespace-nowrap font-medium bg-primary hover:bg-primary/90 h-11 rounded-xl bg-gradient-to-r hover:opacity-90 transition-opacity shadow-soft text-lg px-8 py-6 text-white cursor-pointer '>
                    Get Started
                     <ArrowDown className="w-5 h-5 ml-2 animate-bounce" />
                </a>
            </div>
    </section>
  )
}

export default Hero