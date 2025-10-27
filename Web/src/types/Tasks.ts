export interface Tasks {
  id: number;
  title: string;
  description: string;
  osId: OsId;
  addedDate: string;
}

export type OsId = 0| 1 | 3;

export const OperationalStatus: Record<OsId, string> = {
  0: "All",
  1: "Pending",
  3: "Completed",
};

export const OperationalStatusEnum: Record<string, OsId> = {
 All : 0,
 Pending: 1,
 Completed: 3,
};