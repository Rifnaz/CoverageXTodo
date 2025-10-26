export interface Tasks {
  id: number;
  title: string;
  description: string;
  osId: OsId;
  addedDate: string;
}

export type OsId = 1 | 3;

export const OperationalStatus: Record<OsId, string> = {
  1: "Pending",
  3: "Completed",
};

