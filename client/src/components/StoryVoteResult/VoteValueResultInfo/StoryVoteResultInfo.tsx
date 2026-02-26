import React from 'react';
import './StoryVoteResultInfo.css';

export interface IStoryVoteResultInfoRowProps {
  className?: string;
  voteValueMark: string;
  playersCount: number;
  playersPercentagePerVote: string;
}

const StoryVoteResultInfoRow: React.FunctionComponent<IStoryVoteResultInfoRowProps> = (props) => {
  return (
    <li className={props.className}>
      <span className='vote_value_mark'>
        {(props.voteValueMark === '☕' ? '☕' : props.voteValueMark) ||
          (props.voteValueMark === '' ? '?' : props.voteValueMark)}
      </span>
      <span className='vote_value_info'>
        {props.playersPercentagePerVote}% ({props.playersCount} player)
      </span>
    </li>
  );
};

export default StoryVoteResultInfoRow;
