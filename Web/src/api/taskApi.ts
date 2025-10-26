import axiosClient from "./axiosClient";
import type { OsId, Tasks } from "../types/Tasks";
import type { Response } from "../types/Response";

export const taskApi = {
    getAll: async (): Promise<Tasks[]> => {
        const response = await axiosClient.get("/home");
        return response.data;
    },

    create: async (task: Partial<Tasks>): Promise<Response> => {
        const { title, description } = task;

        const response = await axiosClient.post("/home", { title, description });
        
        return response.data;
    },

    delete: async (id: number): Promise<Response> => {
        const response = await axiosClient.delete(`/home/${id}`);
        return response.data;
    },

    updateStatus: async (id: number, osId: OsId): Promise<Response> => {
        const response = await axiosClient.put(`/home/${id}/${osId}`);
        return response.data;
    },
}