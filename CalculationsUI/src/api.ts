const BASE_URL = "http://localhost:29722";

export interface Operation {
  operation: number;
  name: string;
}

export async function fetchOperations(): Promise<Operation[]> {
  const res = await fetch(`${BASE_URL}/Calculation/operations`);
  if (!res.ok) throw new Error("Failed to fetch operations");
  return res.json();
}

export interface CalculationRequest {
  a: string;
  b: string;
  operation: number;
}

export interface HistoryEntry {
  a: string;
  b: string;
  result: string;
  performedAt: string;
}

export interface CalculationResponse {
  result: number;
  lastThreeSameTypeOperations: HistoryEntry[];
  sameTypeOperationsThisMonth: number;
}

export async function calculate(req: CalculationRequest): Promise<CalculationResponse> {
  const res = await fetch(`${BASE_URL}/Calculation/with-history`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(req),
  });
  if (!res.ok) throw new Error("Calculation failed");
  return res.json();
}
