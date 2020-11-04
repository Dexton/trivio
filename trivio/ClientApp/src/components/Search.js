import React, {Fragment, useState} from 'react';
import { Col } from 'reactstrap';
import {Card} from './Card';

export function Search() {
    const [value, setValue] = useState("");
    const [response, setResponse] = useState(null);
    const [loading, setLoading] = useState(false);

    const getResponse = () => {
        // Reset state
        setResponse(null);
        setValue("");
        setLoading(true);
        //Fetch data and parse from json stream
        fetch(`/fact/${value}`).then(
            (res) => res.json())
            .then( (json) => {
                setLoading(false);
                json.forEach( el => 
                    ( setResponse(el.summary) )
                )
            }
        ).catch((error) => {
            setLoading(false);
            console.log(error);
        });
    };

    return (
        <Fragment>
            <Col sm="12" md={{ size: 6, offset: 3 }} className="input-group mb-3">
                <input value={value} type="text" class="form-control" placeholder="Fetch weather" onChange={e => setValue(e.target.value)}/>
                <div class="input-group-append">
                    <button class="btn btn-outline-secondary" disabled={loading} type="button" onClick={getResponse}>
                        { loading ? 
                                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                            : "Fetch"
                        }
                    </button>
                </div>
            </Col>
            <Col sm="12" md={{ size: 6, offset: 4 }}>
                {value}
                <Card title="Forecast" message={response} />
            </Col>
        </Fragment>
    );
}
