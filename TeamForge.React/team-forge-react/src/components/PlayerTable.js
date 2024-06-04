import React from 'react';

const PlayerTable = ({ players }) => {
    return (
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Height</th>
                    <th>Weight</th>
                    <th>Age</th>
                    <th>Blocking</th>
                    <th>Attacking</th>
                    <th>Serving</th>
                    <th>Passing</th>
                    <th>Setting</th>
                </tr>
            </thead>
            <tbody>
                {players.map((player) => (
                    <tr key={player.id}>
                        <td>{player.name}</td>
                        <td>{player.height}</td>
                        <td>{player.weight}</td>
                        <td>{player.age}</td>
                        <td>{player.blocking}</td>
                        <td>{player.attacking}</td>
                        <td>{player.serving}</td>
                        <td>{player.passing}</td>
                        <td>{player.setting}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
};

export default PlayerTable;