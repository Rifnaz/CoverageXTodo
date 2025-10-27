import axiosClient from "./axiosClient";
import { type OsId, type Tasks, OperationalStatusEnum } from "../types/Tasks";
import type { Response } from "../types/Response";

export const taskApi = {
    getAll: async (): Promise<Tasks[]> => {
        const response = await axiosClient.get("/home");
        return response.data;
    },

    getByStatus: async (osId: number): Promise<Tasks[]> => {
        const response = await axiosClient.get(`/home/byOs/${osId}`);
        return response.data;
    },

    create: async (task: Partial<Tasks>): Promise<Response> => {
        const { title, description } = task;

        try {
            const response = await axiosClient.post("/home", { title, description });
            return response.data;

        } catch(err: any){
            console.log(err.response.data.message);
            err.response.data.message = "Something went wrong."
            return err.response.data;
        }        
    },

    delete: async (id: number): Promise<Response> => {
        try {
            const response = await axiosClient.delete(`/home/${id}`);
            return response.data;
            
        } catch(err: any){
            console.log(err.response.data.message);
            err.response.data.message = "Something went wrong."
            return err.response.data;
        }
    },

    updateStatus: async (id: number, osId: OsId): Promise<Response> => {
        try {
            const response = await axiosClient.put(`/home/${id}/${osId}`);
            return response.data;
            
        } catch(err: any){
            console.log(err.response.data.message);
            err.response.data.message = "Something went wrong."
            return err.response.data;
        }
    },
}