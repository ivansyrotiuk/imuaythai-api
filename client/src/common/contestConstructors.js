export function createContestRing(contestDay) {
    return {
        contestDay: contestDay,
        ringsCount: 1,
        contestId: 0,
        ringsAvilability: [{
            from: contestDay,
            to: contestDay,
            name: 'A',
            id: 0
        }]
    }
}

export function createRingAvailability(contestDate, ringName) {
    return {
        from: contestDate,
        to: contestDate,
        name: ringName
    }
}

export function createContest(institutionId) {
    return {
        date: new Date(),
        endRegistrationDate: new Date(),
        institutionId: institutionId,
        rings: []
    }
}