import React from 'react';

const ValidationErrorMessages = ({ formErrors }) =>
    <div className='formErrors'>
        {Object.keys(formErrors).map((fieldName, i) => {
            if (formErrors[fieldName].length > 0) {
                return (
                    <li className="text-danger" key={i}>{fieldName} {formErrors[fieldName]}</li>
                )
            } else {
                return '';
            }
        })}
    </div>

export default ValidationErrorMessages;