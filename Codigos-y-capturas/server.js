const express = require('express');
const cors = require('cors');
const sqlite3 = require('sqlite3').verbose();

const app = express();
app.use(cors());
app.use(express.json());

const db = new sqlite3.Database('./DemoRed.db');

app.get('/', (req, res) => {
    res.send('Servidor funcionando correctamente');
});


// Inicio de sesión
app.post('/login', (req, res) => {
    const { usuario, password } = req.body;

    db.get(
        "SELECT * FROM usuarios WHERE username = ? AND password = ?",
        [usuario, password],
        (err, row) => {

            if (!row) {
                return res.json({ ok: false });
            }

            const fechaInicio = new Date().toISOString();

            db.run(
                "INSERT INTO sesiones (id_usuario, fecha_inicio) VALUES (?, ?)",
                [row.id_usuario, fechaInicio],
                function () {
                    res.json({
                        ok: true,
                        sesionId: this.lastID
                    });
                }
            );
        }
    );
});

//  Cierre de sesión
app.post('/logout', (req, res) => {
    const { sesionId } = req.body;

    const fechaFin = new Date().toISOString();

    db.run(
        "UPDATE sesiones SET fecha_fin = ? WHERE id_sesion = ?",
        [fechaFin, sesionId],
        () => {
            res.json({ ok: true });
        }
    );
});

app.listen(3000, () => {
    console.log("Servidor corriendo en http://localhost:3000");
});