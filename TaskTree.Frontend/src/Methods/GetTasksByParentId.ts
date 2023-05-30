import Task from "../Models/Task";

export default async function GetTasksByParentId(parentId: string) {
    try {
        const response = await fetch('https://localhost:7185/api/task/' + parentId, {
          method: 'GET',
          headers: {
            Accept: 'application/json',
          },
        });

        if (!response.ok) {
          throw new Error(`Error! status: ${response.status}`);
        }

        const result = JSON.parse((await response.json())) as Task[];

        return result;

      } catch {
          throw new Error("API is down");
      }
}