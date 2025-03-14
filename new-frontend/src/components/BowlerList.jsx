import React, { useState, useEffect } from 'react';
import '../styles/BowlerList.css';

function BowlerList() {
  const [bowlers, setBowlers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchBowlers = async () => {
      try {
        const response = await fetch('https://localhost:5116/api/Bowler');
        
        if (!response.ok) {
          throw new Error(`API request failed with status ${response.status}`);
        }
        
        const data = await response.json();
        setBowlers(data);
        setLoading(false);
      } catch (err) {
        console.error('Error fetching bowler data:', err);
        setError('Failed to load bowlers. Please try again later.');
        setLoading(false);
      }
    };

    fetchBowlers();
  }, []);

  if (loading) {
    return <div className="loading">Loading bowler data...</div>;
  }

  if (error) {
    return <div className="error">{error}</div>;
  }

  return (
    <div className="bowler-list-container">
      <h2>Team Members</h2>
      <table className="bowler-table">
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((bowler) => (
            <tr key={bowler.bowlerId}>
              <td>{bowler.bowlerName}</td>
              <td>{bowler.teamName}</td>
              <td>{bowler.address}</td>
              <td>{bowler.city}</td>
              <td>{bowler.state}</td>
              <td>{bowler.zip}</td>
              <td>{bowler.phone}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default BowlerList;