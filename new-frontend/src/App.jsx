import React from 'react';
import Header from './components/Header';
import BowlerList from './components/BowlerList';
import './App.css';

function App() {
  return (
    <div className="app">
      <Header />
      <main>
        <BowlerList />
      </main>
      <footer>
        <p>&copy; 2025 Bowling League Database</p>
      </footer>
    </div>
  );
}

export default App;
