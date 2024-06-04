import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import TeamList from './components/TeamList';
import TeamForm from './components/TeamForm';
import TeamDetail from './components/TeamDetail';
import PlayerList from './components/PlayerList';
import PlayerForm from './components/PlayerForm';
import ScoreList from './components/ScoreList';
import ScoreForm from './components/ScoreForm';
import ScoreDetail from './components/ScoreDetail';
import CoachList from './components/CoachList';
import CoachForm from './components/CoachForm';
import CoachDetail from './components/CoachDetail';
import Login from './components/Login';
import Register from './components/Register';


function App() {
  return (
    <Router>
      <div>
        <Routes>
          <Route path="/" element={<TeamList />} />
          <Route path="/teams/new" element={<TeamForm />} />
          <Route path="/teams/:id" element={<TeamDetail />} />
          <Route path="/teams/:id/edit" element={<TeamForm editMode />} />
          <Route path="/players" element={<PlayerList />} />
          <Route path="/players/new" element={<PlayerForm />} />
          <Route path="/players/:id/edit" element={<PlayerForm />} />
          <Route path="/scores" element={<ScoreList />} />
          <Route path="/scores/new" element={<ScoreForm />} />
          <Route path="/scores/:id" element={<ScoreDetail />} />
          <Route path="/scores/:id/edit" element={<ScoreForm editMode />} />
          <Route path="/coaches" element={<CoachList />} />
          <Route path="/coaches/new" element={<CoachForm />} />
          <Route path="/coaches/:id" element={<CoachDetail />} />
          <Route path="/coaches/:id/edit" element={<CoachForm editMode />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          
        </Routes>
      </div>
    </Router>
  );
}

export default App;