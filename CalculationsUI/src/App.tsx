import { useEffect, useState } from 'react'
import './App.css'
import { calculate, fetchOperations, type CalculationResponse, type Operation } from './api'

function App() {
  const [fieldA, setFieldA] = useState('')
  const [fieldB, setFieldB] = useState('')
  const [operation, setOperation] = useState('')
  const [operations, setOperations] = useState<Operation[]>([])
  const [response, setResponse] = useState<CalculationResponse | null>(null)
  const [error, setError] = useState<string | null>(null)

  useEffect(() => {
    fetchOperations()
      .then(setOperations)
      .catch(() => setError('Failed to load operations'))
  }, [])

  const handleCalculate = async () => {
    setError(null)
    setResponse(null)
    try {
      const res = await calculate({ a: fieldA, b: fieldB, operation: Number(operation) })
      setResponse(res)
    } catch {
      setError('Calculation failed')
    }
  }

  return (
    <div className="card">
      <h1>Calculator</h1>

      <div>
        <label>Field A</label>
        <input
          type="number"
          value={fieldA}
          onChange={e => setFieldA(e.target.value)}
          placeholder="Enter value A"
        />
      </div>

      <div>
        <label>Operation</label>
        <select value={operation} onChange={e => setOperation(e.target.value)}>
          <option value="">-- Select operation --</option>
          {operations.map(op => (
            <option key={op.operation} value={op.operation}>{op.name}</option>
          ))}
        </select>
      </div>

      <div>
        <label>Field B</label>
        <input
          type="number"
          value={fieldB}
          onChange={e => setFieldB(e.target.value)}
          placeholder="Enter value B"
        />
      </div>

      <button onClick={handleCalculate} disabled={operation === ''}>
        Calculate
      </button>

      {response !== null && (
        <div>
          <div>
            <strong>Result:</strong> {response.result}
          </div>

          <div>
            <strong>Operations this month:</strong> {response.sameTypeOperationsThisMonth}
          </div>

          {response.lastThreeSameTypeOperations.length > 0 && (
            <div>
              <strong>Last 3 operations of this type:</strong>
              <table>
                <thead>
                  <tr>
                    <th>A</th>
                    <th>B</th>
                    <th>Result</th>
                    <th>Performed At</th>
                  </tr>
                </thead>
                <tbody>
                  {response.lastThreeSameTypeOperations.map((entry, i) => (
                    <tr key={i}>
                      <td>{entry.a}</td>
                      <td>{entry.b}</td>
                      <td>{entry.result}</td>
                      <td>{new Date(entry.performedAt).toLocaleString()}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          )}
        </div>
      )}

      {error && (
        <div style={{ color: 'red' }}>{error}</div>
      )}
    </div>
  )
}

export default App
