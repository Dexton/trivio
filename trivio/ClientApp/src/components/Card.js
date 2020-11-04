import React from 'react';

export const Card = ({title, message}) => {
    return (
        message ? (
            <div class="card" style={{width: "18rem"}}>
                <div class="card-body">
                    <h5 class="card-title">{title}</h5>
                    <h6 class="card-subtitle mb-2 text-muted">{message}</h6>
                </div>
            </div>
        )
        : null
    );
}